all:
	msbuild.exe

test: nmap_results.xml
test: ./bin/Debug/nmap_query.exe
	./bin/Debug/nmap_query.exe

xml: nmap_results.xml
nmap_results.xml:
	nmap -oX - --open -sU -sT -p T:22,80-81,443,1770-1771,3389,U:1770-1771,2051,2060,5926 10.0.2.0/24 >$@
