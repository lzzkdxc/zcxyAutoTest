﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest
{
    public class ExerciseHandler
    {
        public static char[] reversibleOps = { '+', '*' };
        
        public static bool Calculate(string exercise)
        {
            if (exercise.Contains('/'))
            {
                var answer = exercise.Split('=')[1];
                var ops = exercise.Replace(answer,"").Split('/');
                
                if (int.Parse(ops[0]) % int.Parse(ops[1]) == 0)
                {
                    if (answer.Contains('.')) return false;
                    return int.Parse(ops[0]) / int.Parse(ops[1]) == int.Parse(answer);
                }
                else
                {
                    if (!answer.Contains('.')) return false;
                    var ans = answer.Replace("...", " ").Split(' ');
                    return int.Parse(ops[1]) * int.Parse(ans[0]) + int.Parse(ans[1]) == int.Parse(ops[0]);
                }
            }
            else
            {
                return (bool)new DataTable().Compute(exercise, "");
            }
        }


        public static string Swap(string line)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char op in reversibleOps)
            {
                if (line.Contains(op))
                {
                    var ops = line.Split(op);
                    sb.Append((int.Parse(ops[0]) > int.Parse(ops[1])) ? ops[1] + op + ops[0] : line);
                    return sb.ToString();
                }
            }
            return line;
        }
    }
}
