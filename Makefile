RM = rm

all:
	$(MAKE) -C ConsoleApplication2

metaproj: ConsoleApplication2.sln.metaproj
ConsoleApplication2.sln.metaproj: MSBuildEmitSolution=1
ConsoleApplication2.sln.metaproj:
	msbuild.exe

clean: ConsoleApplication2.sln.metaproj
	msbuild ConsoleApplication2.sln.metaproj /t:Clean
	$(RM) -f ConsoleApplication2.sln.metaproj

.PHONY: clean
.PHONY: all
