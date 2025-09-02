using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddSubtractWebForm.Pages
{
//IndexModel is the code-behind for Index.cshtml 
    public class IndexModel : PageModel
    {
    //BindProperty automatically bind values from Razor Page to this properties
        [BindProperty]
       public int Num1 { get; set; }
        [BindProperty]
        public int Num2 { get; set; }
        [BindProperty]
        public string Operation {  get; set; }
        public int Result { get; set; }
        //Executes when the form is submitted
        public void OnPost()
        {
            if (Operation == "add")
                Result = Num1 + Num2;
            else if(Operation =="subtract")
                Result = Num2 - Num1;
        }

    }
}
