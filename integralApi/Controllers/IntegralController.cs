using integralApi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;


namespace integralApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegralController : ControllerBase
    {
        private readonly IntegralContext db = new();
        private static Eq equ = new();
        [HttpPost("DefiniteIntegral")]
        public async Task<ActionResult<Eq>> GetAnswerDI(string expression, string var, string fstNum, string scndNum)
        {
            if (db != null)
            {
                if (db.Expressions.ToList().FirstOrDefault(x => x.Equation == expression) != null)
                {
                    double tempery = db.Expressions.Single(x => x.Equation == expression).Answer;
                    return Ok(tempery);
                }
                else
                {
                    string ResultExp = "int(" + expression + "," + var + "," + fstNum + "," + scndNum + ")";
                    Expression eq = new(ResultExp);
                    equ.FirstNumber = fstNum;
                    equ.LastNumber = scndNum;
                    equ.Equation = expression;
                    equ.Variable = var;
                    equ.Answer = eq.calculate();
                    await db.AddAsync(equ);
                    await db.SaveChangesAsync();
                }
            }
            return Ok(equ.Answer);
        }
    }
}
