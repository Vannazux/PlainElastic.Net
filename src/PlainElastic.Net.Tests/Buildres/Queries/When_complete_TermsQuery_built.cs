﻿using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(TermsQuery<>))]
    class When_complete_TermsQuery_built
    {
        private Because of = () => result = new TermsQuery<FieldsTestClass>()
                                                .Field(f => f.Property1)
                                                .Values(new[] { "One", "Two" })
                                                .MinimumMatch(2)
                                                .ToString();

        It should_contain_minimum_match_part = () => result.ShouldContain(@"'minimum_match': 2 ".SmartQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'terms': { 'Property1': [ 'one','two' ], 'minimum_match': 2 } }".SmartQuote());

        private static string result;
    }
}