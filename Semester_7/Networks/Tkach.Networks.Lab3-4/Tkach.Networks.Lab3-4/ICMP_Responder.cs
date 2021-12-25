using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Net;
using System.Net.Sockets;

namespace Tkach.Networks.Lab3_4
{
	class ICMP_Responder
	{
		public int Run()
		{
			int sockfd, retval, n;
			socklen_t clilen;
			struct sockaddr_in cliaddr, servaddr;
			char buf[10000];
			int i;
	
			sockfd = socket(AF_INET, SOCK_RAW, IPPROTO_ICMP);
			if (sockfd< 0) {
				perror("sock:");
				exit(1);
			}
			clilen = sizeof(struct sockaddr_in);
			while (true) {
			Console.Writeline(" before recvfrom\n");
			n = recvfrom(sockfd, buf, 10000, 0, (struct sockaddr*)&cliaddr, &clilen);
			Console.Writeline(" rec'd %d bytes\n", n);
	
			struct iphdr* ip_hdr = (struct iphdr*)buf;
	
			Console.Writeline("IP header is %d bytes.\n", ip_hdr->ihl* 4);
	
			for (i = 0; i<n; i++) {
			Console.Writeline("%02X%s", (uint8_t) buf[i], (i + 1) % 16 ? " " : "\n");
			}
			printf("\n");
		
			struct icmphdr*icmp_hdr = (struct icmphdr*)((char*)ip_hdr + (4 * ip_hdr->ihl));
		
			printf("ICMP msgtype=%d, code=%d", icmp_hdr->type, icmp_hdr->code);
		}
	}
}
   
