function TransalteText() {
    $(document)
    var languageCode = "&to=zh-Hans";
            var enterText = $("#enterText").val();
            if (1 <= $("#enterText").val().trim().length && languageCode != "NA") {
                $('#enterText').removeClass('redBorder');
                var url = '/TranslatorText/Translate';
                var dataToSend = { "Text": enterText };
                dataType: "json",
                    $.ajax({
                        url: url,
                        data: dataToSend,
                        type: 'POST',
                        success: function (response) {
                            var result = JSON.parse(response);
                            var translatedText_it = result[0].translations[0].text;
                            var translatedText_de = result[0].translations[1].text;
                            var translatedText_es = result[0].translations[2].text;
                            var translatedText_chinese = result[0].translations[3].text;
                            var translatedText_ar = result[0].translations[4].text;
                            $('#translatedText_it').val(translatedText_it);
                            $('#translatedText_de').val(translatedText_de);
                            $('#translatedText_es').val(translatedText_es);
                            $('#translatedText_chinese').val(translatedText_chinese);
                            $('#translatedText_ar').val(translatedText_ar);
                        }
                    })
            }
            else {
                $('#enterText').addClass('redBorder');
                $('#translatedText').val("");
            }
}