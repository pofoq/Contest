using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Codeforces.Contest
{
    public class Task_S1
    {
        /*
select id, contest_id, code
from problems
where id in (
  select problem_id 
  from submissions  
  where success = 'true'
  group by problem_id
  having count(distinct user_id) > 1
  )
order by id
         */
    }
}
