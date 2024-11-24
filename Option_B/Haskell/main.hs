import System.IO

eliminateEven :: [Int] -> [Int]
eliminateEven nums = [x | (i, x) <- zip [0..] nums, even i]

eliminateOdd :: [Int] -> [Int]
eliminateOdd nums = [x | (i, x) <- zip [0..] nums, odd i]

eliminateThree :: [Int] -> [Int]
eliminateThree nums = [x | (i, x) <- zip [1..] nums, (i `mod` 3) /= 0]

processEliminations :: [Int] -> Int
processEliminations nums
    | length nums == 1 = head nums
    | length afterEvenElimination == 1 = head afterEvenElimination
    | length afterOddElimination == 1 = head afterOddElimination
    | otherwise = processEliminations afterThreeElimination
  where
    afterEvenElimination = eliminateEven nums
    afterOddElimination = eliminateOdd afterEvenElimination
    afterThreeElimination = eliminateThree afterOddElimination

cruelLifeSelection :: Int -> Int
cruelLifeSelection n = processEliminations [1..n]

main :: IO ()
main = do
    input <- readLn :: IO Int
    let result = cruelLifeSelection input
    print result
