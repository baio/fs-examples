module MapString

// AAABBBBCD -> A3B4C1D1

let mapString (str: string) =
    
    let foldStr chr acc =
        match acc with
        | (' ', 0, "") -> 
            chr, 1, ""
        | pervChr, pervCnt, tail -> 
            if chr = pervChr then                
                chr, pervCnt + 1, tail
            else 
                chr, 1, sprintf "%c%i%s" pervChr pervCnt tail
        
    let chr, cnt, tail = Seq.foldBack foldStr str (' ', 0, "")
    sprintf "%c%i%s" chr cnt tail