using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    using System.Xml;

    class MemberAccessSymbol
    {
        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            }.ToDictionary(i => i.Key); // valid spacing around the member accesss symbol
            }
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            } .ToDictionary(i => i.Key); // invalid spacing around the member accesss symbol
            }
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            }. ToDictionary(i => i.Key); // invalid spacing around the member accesss symbol
            }
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            } . ToDictionary(i => i.Key); // invalid spacing around the member accesss symbol
            }
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            }
                            .ToDictionary(i => i.Key); // Valid spacing around the member accesss symbol
            }
        }

        public void Method1()
        {
            var purchase = Match.Against(product)
            .Where<BookProduct>().Then(bookProduct => bookService.Purchase(bookProduct))
            .Where<MusicProduct>().Then(musicProduct => musicService.Purchase(musicProduct));
        }

        public void Method2()
        {
            configuration.CreateMap<ProcessDomainObject, ProcessRequestResponse>()
            .ForMember(dest => dest.Action, opt => opt.Ignore())
            .ForMember(dest => dest.Username, opt => opt.Ignore())
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.ProcessId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FileNameMask, opt => opt.Ignore())
            .ForMember(dest => dest.BookTypeId, opt => opt.Ignore())
            .ForMember(dest => dest.Context, opt => opt.Ignore())
            .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore());
        }

        public void Method1()
        {
            var purchase = Match.Against(product)
.Where<BookProduct>().Then(bookProduct => bookService.Purchase(bookProduct))
            .Where<MusicProduct>().Then(musicProduct => musicService.Purchase(musicProduct));
        }
    }
}
