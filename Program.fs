// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CacheBox

[<EntryPoint>]
let main argv = 
    
    printfn "%A" (getChanges [B_25; B_50; B_25; B_100; B_50])
    0 // return an integer exit code
