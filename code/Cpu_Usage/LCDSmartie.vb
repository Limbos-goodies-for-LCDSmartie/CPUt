Imports System.Diagnostics
Imports System.Management
Imports System.Reflection
Imports System.Text
Imports Microsoft.Win32
Public Class LCDSmartie

    Function GetCpu()
        Dim cpuCounter As New PerformanceCounter("Processor", "% Processor Time", "_Total")

        ' Get the initial value of the counter
        Dim cpuUsage As Single = cpuCounter.NextValue()

        ' Wait one second to get a more accurate reading
        Threading.Thread.Sleep(50)

        ' Get the updated value of the counter
        cpuUsage = cpuCounter.NextValue()
        Return cpuUsage

    End Function


    Public Shared Function GetCurrentCpuFrequency() As Double
        Try
            Dim registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\CentralProcessor\0")
            If registryKey IsNot Nothing Then
                Dim rawValue As Object = registryKey.GetValue("~MHz")
                If rawValue IsNot Nothing Then
                    Dim currentFrequency As Double = CDbl(rawValue)
                    ' Current frequency is in MHz
                    ' You can convert it to GHz by dividing by 1000 if needed
                    Return currentFrequency
                End If
            End If


            Return -1 ' Return -1 if unable to retrieve the information
        Catch ex As Exception
            ' Handle any exceptions that may occur
            Return -1
        End Try
    End Function

    Public Function function1(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Then
            Return "no parameters required [two commas are essential after function number])"

        Else
            Return Math.Round(GetCpu(), 0)
        End If

    End Function


    Public Function function2(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Then
            Return "no parameters required [two commas are essential after function number])"
        Else

            Return Math.Round(GetCpu(), 2)
        End If


    End Function

    Public Function function3(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Then
            Return "no parameters required [two commas are essential after function number])"
        Else

            Return GetCpu()
        End If


    End Function


    Public Function function4(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Then
            Return "no parameters required [two commas are essential after function number])"
        Else

            Return GetCurrentCpuFrequency()
        End If


    End Function





    Public Function function20(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Then
            Return "Created by Nikos Georgousis - 2023"

        Else

            Return "cput v1.1 by Limbo"
        End If


    End Function



    Public Function GetMinRefreshInterval() As Integer

        Return 200 ' 200 ms (around 5 times a second)

    End Function


    Public Function SmartieDemo()
        Dim demolist As New StringBuilder()

        demolist.AppendLine("cput plugin for LCD Smartie")
        demolist.AppendLine("This gives CPU usage info.")
        demolist.AppendLine("It is created as an alternative method to get CPU usage when LCD Smartie cannot provide such value ")
        demolist.AppendLine("(Most of the times the build-in functions are working great).")
        demolist.AppendLine("This plughin can provide 5 values per second.")
        demolist.AppendLine("------ Function1 ------")
        demolist.AppendLine(">>>  Value without decimals   <<<")
        demolist.AppendLine("Current value  $dll(cput,1, , )")
        demolist.AppendLine("------ Function2 ------")
        demolist.AppendLine(">>>  Value with two decimals   <<<")
        demolist.AppendLine("Current value  $dll(cput,2, , )")
        demolist.AppendLine("------ Function3 ------")
        demolist.AppendLine(">>>  Raw value   <<<")
        demolist.AppendLine("Current raw value:  $dll(cput,3, , )")
        demolist.AppendLine("------ Function4 ------")
        demolist.AppendLine(">>>  The CPU freq <<<")
        demolist.AppendLine("Frequency as registry reports it:  $dll(cput,4, , )")
        demolist.AppendLine("------ Function20 ------")
        demolist.AppendLine(">>>  About <<<")
        demolist.AppendLine("Get about info:  $dll(cput,20, , )")
        demolist.AppendLine("------------------------------------------------------------------------------------------------------------------")
        demolist.AppendLine(" *** Visit ***")
        demolist.AppendLine("> Home page")
        demolist.AppendLine("https://lcdsmartie.sourceforge.net")
        demolist.AppendLine("> Forums")
        demolist.AppendLine("https://www.lcdsmartie.org")
        demolist.AppendLine("> Active development branch (latest version)")
        demolist.AppendLine("https://github.com/stokie-ant/lcdsmartie-laz")
        demolist.AppendLine("")

        Dim result As String = demolist.ToString()
        Return result
    End Function

    Public Function SmartieInfo()
        Return "Developer: Nikos Georgousis (limbo)" & vbNewLine & "Version: 1.1 "
    End Function



End Class
