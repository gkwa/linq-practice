RM = rm

all: nmap_query
all: ConsoleApplication2

ConsoleApplication2:
	$(MAKE) -C ConsoleApplication2

nmap_query:
	$(MAKE) -C nmap_query

metaproj: ConsoleApplication2.sln.metaproj
ConsoleApplication2.sln.metaproj:
	msbuild.exe /p:MSBuildEmitSolution=1 ConsoleApplication2.sln

clean: ConsoleApplication2.sln.metaproj
	msbuild ConsoleApplication2.sln.metaproj /t:Clean
	$(RM) -f ConsoleApplication2.sln.metaproj
	msbuild nmap_query.sln.metaproj /t:Clean
	$(RM) -f nmap_query.sln.metaproj

.PHONY: clean
.PHONY: all
.PHONY: nmap_query
.PHONY: ConsoleApplication2
