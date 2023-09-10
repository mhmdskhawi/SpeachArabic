Imports System.Globalization
Imports System.Speech.AudioFormat
Imports System.Speech.Synthesis

Public Class Form1
    Private Sub BtnGetVoices_Click(sender As Object, e As EventArgs) Handles BtnGetVoices.Click
        Using synth As SpeechSynthesizer = New SpeechSynthesizer()

            For Each voice As InstalledVoice In synth.GetInstalledVoices()
                Dim info As VoiceInfo = voice.VoiceInfo
                Dim AudioFormats As String = ""

                For Each fmt As SpeechAudioFormatInfo In info.SupportedAudioFormats
                    AudioFormats += String.Format("{0}" & vbLf, fmt.EncodingFormat.ToString())
                Next

                ListBox1.Items.Add(info.Name)

                TextBox1.AppendText(info.Name & vbNewLine)
                TextBox1.AppendText(info.Culture.DisplayName & vbNewLine)
                TextBox1.AppendText(info.Age & vbNewLine)
                TextBox1.AppendText(info.Gender & vbNewLine)
                TextBox1.AppendText(info.Description & vbNewLine)
                TextBox1.AppendText(info.Id & vbNewLine)
                TextBox1.AppendText(voice.Enabled & vbNewLine)


                If info.SupportedAudioFormats.Count <> 0 Then
                    TextBox1.AppendText(" Audio formats: " & AudioFormats & vbNewLine)

                Else
                    TextBox1.AppendText(" No supported audio formats found" & vbNewLine)

                End If

                Dim AdditionalInfo As String = ""

                For Each key As String In info.AdditionalInfo.Keys
                    AdditionalInfo += String.Format("  {0}: {1}" & vbLf, key, info.AdditionalInfo(key))
                Next
                TextBox1.AppendText(" Additional Info - " & AdditionalInfo & vbNewLine)

                TextBox1.AppendText("ـــــــــــــــــــــــــــــــــــــــ" & vbNewLine)

            Next
        End Using

    End Sub

    Private Sub BtnSpeak_Click(sender As Object, e As EventArgs) Handles BtnSpeak.Click
        Dim speaker = New SpeechSynthesizer()
        ' speaker.Rate = -2
        Dim culture = CultureInfo.GetCultureInfo("ar-SA")
        Dim voices = speaker.GetInstalledVoices(culture)

        If voices.Count > 0 Then
            speaker.SelectVoice(voices(0).VoiceInfo.Name)
            speaker.SpeakAsync(RichTextBox1.Text)
        End If
    End Sub
End Class
