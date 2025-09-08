namespace AddSubtractMvc.Models
{
    // ViewModel to represent the Add/Subtract calculator data
    public class CalculatorViewModel
    {
        // First number entered by the user
        public double Number1 { get; set; }

       
        public double Number2 { get; set; }

        // Operation selected by the user: "Add" or "Subtract"
        public string? Operation { get; set; } // Nullable to fix CS8618 warning

        // Stores the result of the calculation; nullable because it is empty initially
        public double? Result { get; set; }
    }
}
