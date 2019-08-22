      [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertOneToNineteen()
        {
            Assert.AreEqual("four", LinqPracticeCode.ThreeUnitWordDictionary("4"));
            Assert.AreEqual("ten", LinqPracticeCode.ThreeUnitWordDictionary("10"));
            Assert.AreEqual("eighteen", LinqPracticeCode.ThreeUnitWordDictionary("18"));
        }

        [Test]
        public void ConvertTwentyToNinetyNine()
        {
            Assert.AreEqual("seventy", LinqPracticeCode.ThreeUnitWordDictionary("70"));
            Assert.AreEqual("fifty six", LinqPracticeCode.ThreeUnitWordDictionary("56"));
        }

        [Test]
        public void ConvertToHundredthMixed()
        {
            Assert.AreEqual("two hundred", LinqPracticeCode.ThreeUnitWordDictionary("200"));
            Assert.AreEqual("three hundred and ten", LinqPracticeCode.ThreeUnitWordDictionary("310"));
            Assert.AreEqual("five hundred and fourteen", LinqPracticeCode.ThreeUnitWordDictionary("514"));
            Assert.AreEqual("nine hundred and fifty six", LinqPracticeCode.ThreeUnitWordDictionary("956"));
        }

        [Test]
        public void CheckForConversionErrors()
        {
            Assert.AreEqual("Cant be 0", LinqPracticeCode.ThreeUnitWordDictionary("0"));
            Assert.AreEqual("Can't be an empty value", LinqPracticeCode.ThreeUnitWordDictionary(""));
            Assert.AreEqual("Can't be higher than 999", LinqPracticeCode.ThreeUnitWordDictionary("1200"));
        }