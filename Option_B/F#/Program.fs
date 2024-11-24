open System

let rec eliminateEven nums =
    nums |> List.mapi (fun i x -> if i % 2 = 0 then Some x else None) |> List.choose id

let rec eliminateOdd nums =
    nums |> List.mapi (fun i x -> if i % 2 <> 0 then Some x else None) |> List.choose id

let rec eliminateThree nums =
    nums |> List.mapi (fun i x -> if (i + 1) % 3 <> 0 then Some x else None) |> List.choose id

let rec processEliminations nums =
    if List.length nums = 1 then
        nums.Head
    else
        let afterEvenElimination = eliminateEven nums
        if List.length afterEvenElimination = 1 then
            afterEvenElimination.Head
        else
            let afterOddElimination = eliminateOdd afterEvenElimination
            if List.length afterOddElimination = 1 then
                afterOddElimination.Head
            else
                let afterThreeElimination = eliminateThree afterOddElimination
                processEliminations afterThreeElimination

let cruelLifeSelection n =
    let initialList = [1 .. n]
    processEliminations initialList

[<EntryPoint>]
let main argv =
    let n = Int32.Parse(Console.ReadLine())
    let result = cruelLifeSelection n
    printfn "%d" result
    0
