namespace MemorySizer
{
    public class PreApprovedLimit
    {
        public string CpfCnpj { get; set; }
        public decimal PaLimit { get; set; }

        public override string ToString()
        {
            return $"{CpfCnpj} & {PaLimit}";
        }
    }
}