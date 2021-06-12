namespace Solution

module Problem100 =
    
    // See the diophantine equation solver 
    // https://www.alpertron.com.ar/QUAD.HTM, with a = 2, b = 0, c = -1, d = -2, e = 1, f = 0, and
    // the sequence http://oeis.org/A011900, for n = 16.
    let solution max =

        let b = 15L
        let n = 21L

        let rec f b n =
            if n < max then
                let _b = 3L * b + 2L * n - 2L
                let _n = 4L * b + 3L * n - 3L
                f _b _n
            else
                b
        
        f b n