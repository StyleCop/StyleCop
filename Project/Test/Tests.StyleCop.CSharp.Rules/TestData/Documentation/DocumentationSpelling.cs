namespace CSharpAnalyzersTest.TestData.Documentation
{
    /// <summary>
    /// Documentation spelling tests.
    /// </summary>
    public class DocumentationSpelling
    {
        /// <summary>
        /// This summary does not have any spelling mistakes.
        /// </summary>
        public void TextInSummaryDoesNotHaveAnySpellingMistakes()
        {
            
        }

        /// <summary>
        /// This summary contains a misspelling of the word mispelled.
        /// </summary>
        public void TheWordMisspelledIsMisspelledInTheTextInTheSummary()
        {
            
        }

        /// <summary>
        /// This summary contains a hyphenated word (Henin-Hardenne) which should not be indicated as misspelled because the entire word exists as a recognized word.
        /// </summary>
        public void HyphenatedWordThatExistAsARecognizedWordShouldNotBeIndicatedAsBeingMisspelled()
        {

        }

        /// <summary>
        /// This summary contains a camel case word (CompuServ) whose parts should not be indicated as misspelled because the entire word exists as a recognized word.
        /// </summary>
        public void TheFirstPartOfACamelCaseWordThatExistAsARecognizedWordShouldNotBeIndicatedAsBeingMisspelled()
        {

        }

        /// <summary>
        /// This summary contains a camel case word (ProComm) whose second part should not be indicated as misspelled because the entire word exists as a recognized word.
        /// </summary>
        public void TheSecondPartOfACamelCaseWordThatExistAsARecognizedWordShouldNotBeIndicatedAsBeingMisspelled()
        {

        }

        /// <summary>
        /// This method documents two thrown exceptions, and the second one has a spelling error.
        /// </summary>
        /// <exception cref="System.ArgumentException">You lost the argument.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">This text contains a misspelling of the word mispelled.</exception>
        public void TheSecondExceptionElementHasMisspelledText()
        {

        }
    }
}
