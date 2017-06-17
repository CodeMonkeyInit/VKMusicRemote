netsh http add urlacl url=http://192.168.0.100:49865/ user=Все
netsh http add urlacl url=http://192.168.0.100:51235/ user=Все

netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=58938 profile=public remoteip=localsubnet action=allow

netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=49865 profile=public remoteip=localsubnet action=allow