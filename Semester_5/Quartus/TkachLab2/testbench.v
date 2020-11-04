`timescale 1ns / 1ps
module testbench();

reg [5:0] operator;
reg [31:0] a;
reg [31:0] b;
wire [31:0] res;
wire comp_res;

alu dut(operator, a, b, res, comp_res);

initial begin
	operator = 6'b011000; a = 5; b = 6; #10;
	$display("%d+%d=%d", a, b, res);
	operator = 6'b011001; a = 14; b = 3; #10;
	$display("%d-%d=%d", a, b, res);
	operator = 6'b101111; a = 3; b = 2; #10;
	$display("%b^%b=%b", a, b, res);
	operator = 6'b101110; a = 3; b = 2; #10;
	$display("%b|%b=%b", a, b, res);
	operator = 6'b010101; a = 8; b = 14; #10;
	$display("%b&%b=%b", a, b, res);
	operator = 6'b100100; a = 14; b = 6; #10;
	$display("%b>>>%b=%b", a, b, res);
	operator = 6'b100101; a = 7; b = 2; #10;
	$display("%b>>%b=%b", a, b, res);
	operator = 6'b100111; a = 5; b = 2; #10;
	$display("%b<<%b=%b", a, b, res);
	operator = 6'b000000; a = 5; b = -8; #10;
	$display("%d<%d=%d", a, b, comp_res);
	operator = 6'b000001; a = 5; b = -8; #10;
	$display("%du<%d=%d", a, b, comp_res);
	operator = 6'b001010; a = 10; b = 2; #10;
	$display("%d>%d=%d", a, b, comp_res);
	operator = 6'b001011; a = -10; b = 2; #10;
	$display("%du>%d=%d", a, b, comp_res);
	operator = 6'b001100; a = 3; b = 3; #10;
	$display("%d==%d=%d", a, b, comp_res);
	operator = 6'b001101; a = 3; b = 2; #10;
	$display("%d!=%d=%d", a, b, comp_res);
end

endmodule