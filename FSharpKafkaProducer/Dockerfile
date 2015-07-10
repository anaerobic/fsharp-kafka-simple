FROM anaerobic/fsharp-runtime-nuget

MAINTAINER Michael W. Martin <mwm.cal@gmail.com>

RUN mono nuget.exe restore
RUN xbuild /p:BuildWithMono="true" FSharpKafkaProducer.sln

CMD []
ENTRYPOINT ["mono", "FSharpKafkaProducer/bin/Debug/FSharpKafkaProducer.exe"]
