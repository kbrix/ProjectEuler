dir <- dirname(parent.frame(2)$ofile) #run as source

x <- c(1, 64, 729, 1296, 4096, 10000, 15625, 38416, 46656, 50625, 82944, 117649, 194481, 234256, 262144, 456976, 531441, 640000, 944784, 1000000, 1185921, 1336336, 1500625, 1771561, 2085136, 2313441, 2458624, 2985984, 3240000, 4477456, 4826809, 5308416, 6765201, 7290000, 7529536, 9150625, 10556001, 11316496, 11390625, 12446784, 14776336, 14992384, 16777216, 17850625, 20250000, 22667121, 24137569, 28005264, 29246464, 29986576, 34012224, 35153041, 36905625, 40960000, 45212176, 47045881, 52200625, 54700816, 57289761, 60466176, 64000000, 68574961, 74805201, 75898944, 78074896, 81450625, 85525504, 85766121, 96040000)

sapply(x, function(x) numbers::primeFactors(x))
l <- sapply(x, function(x) table(numbers::primeFactors(x)))

s <- NULL

for(i in seq_along(l)) {
  d <- as.data.frame(l[i])
  s[i] <- paste0(d$Var1, "^{", d$Freq, "}", collapse = "cdot")
}

p <- NULL

for(i in seq_along(l)) {
  d <- as.data.frame(l[i])
  p[i] <- paste0(as.numeric(as.character(d$Freq)) %% 6, collapse = ", ")
}

p

library(numbers)

N <- 10^8
n1 <- N^(1/6); n1
n2 <- N^(1/4); n2

n2/(1^(2/3))

i <- (1:n1)^(3/2)
x <- floor(n2/i)

mm <- Vectorize(moebius)

res <- NULL
for(j in seq_along(x)) {
  res[j] <- sum(mm(1:x[j]) == 1)
}

sum(res)


