module ExcludeHolidaysTypes

type InputRow =
    { TradeDate : string
      GbxVol : int
      RthVol : int }

let deserializeInputRow (line : string) =
    let lineArray = line.Split(',')
    
    let currInputRow =
        { TradeDate = lineArray.[0]
          GbxVol = int lineArray.[1]
          RthVol = int lineArray.[2] }
    currInputRow
