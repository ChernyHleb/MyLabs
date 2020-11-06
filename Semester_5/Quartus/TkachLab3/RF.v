module RF (
	input clk,
	input reset,
	input [4:0] A1,
	input [4:0] A2,
	input [4:0] A3,
	input [31:0] WD3,
	input WE3, // enable write mode
	output [31:0] RD1,
	output [31:0] RD2
);

integer i;

reg [31:0] RAM [0:15];
initial RAM[0] = 0;

assign RD1 = RAM[A1];
assign RD2 = RAM[A2];

always @ (posedge clk)
begin
	if(WE3 & A3 != 0) RAM[A3] <= WD3;
	if(reset)
		for(i = 1; i < 16; i= i + 1)
			RAM[i] <= RAM[0];
end	

endmodule