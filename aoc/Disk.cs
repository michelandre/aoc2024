using System.Runtime;
using System.Text;

namespace aoc;

public class Disk
{
    private int[] _blocks;

    private struct Block
    {
        public int Index;
        public int Length;
    };
    
    private List<Block> _freeBlocks;
    private List<Block> _usedBlocks;

    public Disk(int blocks)
    {
        _blocks = new int[blocks];
        _freeBlocks = new List<Block>(blocks);
        _usedBlocks = new List<Block>(blocks);
        Array.Fill(_blocks, int.MinValue);
    }

    public int BlockCount => _blocks.Length;
    public override string ToString()
    {
        var sb = new StringBuilder(_blocks.Length);
        Array.ForEach(_blocks, b => sb.Append(b != -1 ? (char)(b + '0') : '.'));
        return sb.ToString();
    }

    public static Disk FromDiskMap(string diskMapString)
    {
        var blockCount = diskMapString.Sum((c => c - '0'));
        var disk = new Disk(blockCount);
        var blockIndex = 0;
        for (var i = 0; i < diskMapString.Length; i++)
        {
            var length = diskMapString[i] - '0';
            var content = (i % 2) == 0 ? (i /2): -1; 
            disk.WriteBlocks(blockIndex, length, content);
            blockIndex += length;
        }
        return disk;
    }

    public void Compact()
    {
        var lastUsedBlockIndex = _blocks.Length;
        do
        {
            while (_blocks[--lastUsedBlockIndex] == -1);
            var firstUnusedBlockIndex = -1;
            while (_blocks[++firstUnusedBlockIndex] != -1);
            if (firstUnusedBlockIndex > lastUsedBlockIndex)
                break;
            _blocks[firstUnusedBlockIndex] = _blocks[lastUsedBlockIndex];
            _blocks[lastUsedBlockIndex] = -1;
        } while (true);
    }

    public void BlockCompact()
    {
        for (var i = _usedBlocks.Count - 1; i >= 0; i--)
        {
            var usedBlock = _usedBlocks[i];
            var freeIndex = _freeBlocks.FindIndex(b => b.Length >= usedBlock.Length);
            if (freeIndex == -1) continue;
            var freeBlock = _freeBlocks[freeIndex];
            if (freeBlock.Index > usedBlock.Index) continue;
            
            WriteBlocks(
                freeBlock.Index, 
                usedBlock.Length, 
                _blocks[usedBlock.Index], 
                false);
            WriteBlocks(
                usedBlock.Index, 
                usedBlock.Length,
                -1, 
                false);

            usedBlock.Index = freeBlock.Index;
            freeBlock.Index += usedBlock.Length;
            freeBlock.Length -= usedBlock.Length;
            _freeBlocks[freeIndex] = freeBlock;
            _usedBlocks[i] = usedBlock;
        }

    }
    
    public long Checksum
    {
        get
        {
            long checksum = 0; 
            for(var i = 0; i < _blocks.Length; i++)
                checksum += _blocks[i] != -1 ? _blocks[i] * i : 0;
            return checksum;
        }
    }

    private void WriteBlocks(int blockIndex, int length, int content, bool maintainBlockList = true)
    {
        var end = length + blockIndex;
        for(var i = blockIndex; i < end; ++i)
            _blocks[i] = content;
        var block = new Block() { Index = blockIndex, Length = length };
        
        if (!maintainBlockList)
            return;
        
        if (content != -1) 
            _usedBlocks.Add(block);
        else
            _freeBlocks.Add(block);
        
    }
}