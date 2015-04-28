FROM anaerobic/fsharp-runtime-nuget

RUN mono nuget.exe restore
RUN xbuild /p:BuildWithMono="true" FSharpKafkaConsumer.sln

CMD []
ENTRYPOINT ["mono", "FSharpKafkaConsumer/bin/Debug/FSharpKafkaConsumer.exe"]
