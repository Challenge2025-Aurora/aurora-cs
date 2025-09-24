namespace Application.DTOs.Request
{
    public class DeteccaoRequestDto
    {
        public string? Placa { get; set; }
        public string? ModeloProb { get; set; }
        public double Confianca { get; set; }

        public int BboxX { get; set; }
        public int BboxY { get; set; }
        public int BboxW { get; set; }
        public int BboxH { get; set; }

        public string? SetorEstimado { get; set; }
        public string? SlotEstimado { get; set; }
    }
}
