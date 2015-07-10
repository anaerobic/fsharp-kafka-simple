FROM anaerobic/fsharp-runtime-nuget

MAINTAINER Michael W. Martin <mwm.cal@gmail.com>

RUN mono nuget.exe restore
RUN xbuild /p:BuildWithMono="true" FSharpKafkaConsumer.sln

CMD []
ENTRYPOINT ["mono", "FSharpKafkaConsumer/bin/Debug/FSharpKafkaConsumer.exe"]
