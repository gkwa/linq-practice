all:
	msbuild.exe

test: nmap_results.xml
test: ./bin/Debug/nmap_query.exe
	./bin/Debug/nmap_query.exe

xml: nmap_results.xml
nmap_results.xml:
	nmap -oX - --open -sU -sT -p T:80,U:1770-1771 10.0.2.0/24 >$@
