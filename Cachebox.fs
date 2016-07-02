module CacheBox

    //[25, 25, 25, 50] -> OK
    //[100] -> NOT OK
    //[25, 50, 100] -> OK

    type BILL = 
        | B_25
        | B_50
        | B_100

    type Cachebox = { b_25: int; b_50: int; b_100: int}

    let (|HAS_25|HAS_25_50|HAS_25_25_25|HAS_NOT|) (cachebox: Cachebox) =
        if cachebox.b_25 >= 1 && cachebox.b_50 >= 1  then
            HAS_25_50
        else if cachebox.b_25 >= 3 then
            HAS_25_25_25
        else if cachebox.b_25 >= 1 then
            HAS_25
        else 
            HAS_NOT        

    let getChange (bill: BILL) (cachebox: Cachebox) =
    
        match bill with
        | B_25 -> 
            true, { cachebox with b_25 = cachebox.b_25 + 1 }
        | B_50 -> 
            match cachebox with
            | HAS_25 ->
                true, { cachebox with b_25 = cachebox.b_25 - 1;  b_50 = cachebox.b_50 + 1}
            | _ ->
                false, cachebox
        | B_100 -> 
            match cachebox with
            | HAS_25_50 ->
                true, { cachebox with b_25 = cachebox.b_25 - 1;  b_50 = cachebox.b_50 - 1; b_100 = cachebox.b_100 + 1}
            | HAS_25_25_25 ->
                true, { cachebox with b_25 = cachebox.b_25 - 3;  b_100 = cachebox.b_100 + 1}
            | _ ->
                false, cachebox
        
    let rec _getChanges (bills: BILL list) (cachebox: Cachebox) =
        match bills with
            | head::tail ->
                match getChange head cachebox with
                | true, newCachebox -> _getChanges tail newCachebox
                | false, _ -> false
            | _ -> true               

    let getChanges (bills: BILL list) = _getChanges bills {b_25 = 0; b_50 = 0; b_100 = 0;}