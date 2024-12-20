namespace aoc;

public class ChronoSpatialComputer
{
    private const int A = 4;
    private const int B = 5;
    private const int C = 6;

    private const int OpcodeAdv = 0;
    private const int OpcodeBxl = 1;
    private const int OpcodeBst = 2;
    private const int OpcodeJnz = 3;
    private const int OpcodeBxc = 4;
    private const int OpcodeOut = 5;
    private const int OpcodeBdv = 6;
    private const int OpcodeCdv = 7;
    
    private readonly int[] _program;
    private readonly long[] _registers = [0, 1, 2, 3, 0, 0, 0, 0];
    private int _ip = 0;
    private List<int> _output = [];
    private Action<int>[] _operations = new Action<int>[8];
    
    public ChronoSpatialComputer(long regA, long regB, long regC, int[] program)
    {
        _registers[A] = regA;
        _registers[B] = regB;
        _registers[C] = regC;
        _program = program;
        _operations[OpcodeAdv] = OpAdv;    
        _operations[OpcodeBxl] = OpBxl;
        _operations[OpcodeBst] = OpBst;    
        _operations[OpcodeJnz] = OpJnz;
        _operations[OpcodeBxc] = OpBxc;    
        _operations[OpcodeOut] = OpOut;
        _operations[OpcodeBdv] = OpBdv;    
        _operations[OpcodeCdv] = OpCdv;
    }

    public static ChronoSpatialComputer FromString(string input)
    {
        var lines = input.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var regA = int.Parse(lines[0].Replace("Register A: ", string.Empty));
        var regB = int.Parse(lines[1].Replace("Register B: ", string.Empty));
        var regC = int.Parse(lines[2].Replace("Register C: ", string.Empty));
        var program = lines[4].Replace("Program: ", string.Empty).Split(',').Select(int.Parse).ToArray();
        return new ChronoSpatialComputer(regA, regB, regC, program);
    }
    
    public long RegA => _registers[A];
    public long RegB => _registers[B];
    public long RegC => _registers[C];
    public int[] Output => _output.ToArray();
    public int Ip => _ip;
    public int[] Program => _program;

    public bool Execute()
    {
        var opCode = _program[_ip++];
        var operand = _program[_ip++];
        _operations[opCode](operand);
        //TestContext.Out.WriteLine($"{_ip} -> {RegA},{RegB},{RegC}"); 
        return _ip < _program.Length;
    }

    private void OpAdv(int operand) => OpDv(operand, A);
    private void  OpBxl(int operand)  => _registers[B] ^= operand;
    private void  OpBst(int operand) => _registers[B] = _registers[operand] % 8;
    private void  OpJnz(int operand)  => _ip = _registers[A] == 0 ? _ip : operand;
    private void  OpBxc(int _)  => _registers[B] ^= _registers[C];
    private void  OpOut(int operand) => _output.Add((int)(_registers[operand] % 8));
    private void  OpBdv(int operand)  => OpDv(operand, B);
    private void  OpCdv(int operand)  => OpDv(operand, C);
    private void OpDv(int operand, int reg)
    {
        try
        {
            _registers[reg] = _registers[A] / (int)Math.Pow(2, _registers[operand]);
        }
        catch (DivideByZeroException)
        {
            _registers[reg] = int.MaxValue;
        }
    }

    public int ExecuteWith(long regA, long regB, long regC)
    {
        _ip = 0;
        _output.Clear();
        _registers[A] = regA;
        _registers[B] = regB;
        _registers[C] = regC;
        var steps = 0;
        while (Execute() && steps < 1000) 
            ++steps;
        return steps;
    }
}