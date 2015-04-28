open KafkaNet
open KafkaNet.Model
open KafkaNet.Protocol
open System
open System.Collections.Generic
open System.Configuration
open System.IO
open System.Reactive.Concurrency
open System.Threading
open StreamStuff

let printMe s = printfn "%s" s

let getTopic (argv : string []) = 
    match argv.Length with
    | len when len > 1 -> argv.[1]
    | _ -> failwithf "topic sux"

let produceWith (producer : Producer) topic messages = 
    try 
        producer.SendMessageAsync(topic, messages)
        |> Async.AwaitTask
        |> ignore
    with
    | :? System.AggregateException as ex -> 
        for ix in ex.InnerExceptions do
            ix.InnerException.Message |> printMe
    | ex -> printMe ex.Message

[<EntryPoint>]
let main argv = 
    let input = 
        if argv.Length = 1 then File.OpenRead argv.[0] :> Stream
        else Console.OpenStandardInput()
    
    let topic = getTopic argv
    let producer = 
        new Producer(new BrokerRouter(new KafkaOptions(new Uri(ConfigurationManager.AppSettings.Item("KafkaUrl")))))
    try 
        loadLines input
        |> Seq.map (fun x -> new Message(x))
        |> produceWith producer topic
    finally
        producer.Dispose()
    printfn "Done"
    if argv.Length = 1 then Console.ReadKey() |> ignore
    0 // return an integer exit code
