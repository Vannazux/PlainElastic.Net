using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(KstemTokenFilter))]
    class When_complete_KstemTokenFilter_built
    {
        Because of = () => result = new KstemTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'kstem'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'kstem'," +
                                                                    "'version': '3.6'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}