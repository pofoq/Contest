using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Codeforces.Contest
{
    public class Task_S2
    {
        /*
         select * from (
select id, name, 
	case when sum(solved) is null then 0 else sum(solved) end solved_at_least_one_contest_count,
	case when count(all1) is null then 0 else count(all1) end take_part_contest_count
from users left join
(
  select user_id, 
          case when sum(solved) = 0 then null else 1 end solved,
          count(*) all1
  from 
    ( 
          select user_id, 
                contests.id as contests_id, 
                sum(case success when 'true' then 1 else 0 end) solved
          from submissions 
              inner join problems on submissions.problem_id = problems.id
              inner join contests on problems.contest_id = contests.id
          group by user_id, contests.id, problems.id
    ) t 
  group by user_id, contests_id 
) t on users.id = t.user_id
  group by id, name
) t
order by solved_at_least_one_contest_count desc, take_part_contest_count desc 

         */
    }
}
