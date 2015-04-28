#!/bin/bash
 
if [[ $1 != "" ]]
then
        wget -c "$1";
        sudo shutdown -k 0;
else
        echo "Usage: sudo ./downloadAndShutdown <fileToDownload>";
fi

git pull origin

docker build -t fsharp-kafka-producer FSharpKafkaProducer

docker build -t fsharp-kafka-consumer FSharpKafkaConsumer