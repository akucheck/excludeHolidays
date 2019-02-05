// excludeHolidays.fs
(*
usage: cat inFile | excludeHolidays  > outFile.txt

Expected input: summary csv, consisting of:  

// tradeDate, gbxVolume, rthVolume
2010-12-09,32992,620422
2010-12-10,133011,946680
2010-12-13,163973,1317348
2010-12-14,221284,1379278
2010-12-15,226629,1649967

Expected output: 
same format with holidays filtered out
 
*)

module excludeHolidays =
    open System
    open FilterIoLib
    open Holidays
    open ExcludeHolidaysTypes

    let excludeHolidays (line:string) =
        let currRow = deserializeInputRow line 
        let dateUnderTest = currRow.TradeDate
        let holiday = isHoliday dateUnderTest holidays 
        not holiday

    [<EntryPoint>]
    let main _argv =
        let _rows =
            Seq.initInfinite readInput
            |> Seq.takeWhile ((<>) null)
            |> Seq.filter excludeHolidays
            |> Seq.iter writeOutput
            
        0 // return an integer exit code 
// ========================================================
// ** end main ** 
// ========================================================