/****** 36110033******/
using System.Threading;

use Darko
--select * from [dbo].[One]
--select * from[dbo].[Two]
--select* from[dbo].[Three]
--select * from[dbo].[Four]

SELECT distinct  * , ',' FROM 
[dbo].[One] as a
cross join[dbo].[Two] as b
cross join[dbo].[Three] as c
cross join[dbo].[Four] as d
--cross join[dbo].[Zero] as e
--cross join[dbo].[Zero] as f
--cross join[dbo].[Three] as g
--cross join[dbo].[Three] as h
