library verilog;
use verilog.vl_types.all;
entity alu is
    port(
        operator_i      : in     vl_logic_vector(5 downto 0);
        operand_a_i     : in     vl_logic_vector(31 downto 0);
        operand_b_i     : in     vl_logic_vector(31 downto 0);
        result_o        : out    vl_logic_vector(31 downto 0);
        comparison_result_o: out    vl_logic
    );
end alu;
