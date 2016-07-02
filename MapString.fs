module MapString

// AAABBBBCD -> A3B4C1D1

let mapString (str: string) =
    
    let foldStr chr acc =
        match acc with
        | (pervChr, cnt)::tail -> 
            if chr = pervChr then                
                (chr, cnt + 1)::tail
            else 
                (chr, 1)::acc
        | [] -> 
            [(chr, 1)]

    
    //YES O(N*2)
    Seq.foldBack foldStr str []
    |> List.fold (fun acc (chr, cnt) -> sprintf "%s%c%i" acc chr cnt) ""