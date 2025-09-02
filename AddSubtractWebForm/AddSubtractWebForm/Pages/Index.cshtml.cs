using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddSubtractWebForm.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
       public int Num1 { get; set; }
        [BindProperty]
        public int Num2 { get; set; }
        [BindProperty]
        public string Operation {  get; set; }
        public int Result { get; set; }
        public void OnPost()
        {
            if (Operation == "add")
                Result = Num1 + Num2;
            else if(Operation =="subtract")
                Result = Num2 - Num1;
        }

    }
}
