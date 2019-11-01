# Cognitive Minion

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ops-ai_cognitive-minion&metric=alert_status)](https://sonarcloud.io/dashboard?id=ops-ai_cognitive-minion)
[![Build Status](https://opsai.visualstudio.com/Cognitive%20Minion/_apis/build/status/ops-ai.cognitive-minion?branchName=master)](https://opsai.visualstudio.com/Cognitive%20Minion/_build/latest?definitionId=1&branchName=master)

## Alexa for business process automation. 
We had a lot of simple scripts created as xUnit tests in our projects to deal with custom requests that came up from time to time, but for which we didn't have time (or weren't worth the time) to create a UI for, or require an extra validation step by someone on our team to make sure it's ok to make that change.
This inlcudes things like whitelisting IP addresses for admin access, or moving a user to a different department in a customer's organization, both of which can have security consequences for example, or things like our IT dealing with hundreds of email distribution list creations and changes to name a few.

We want to automate these simple 5-minute requests in less time than it takes to just do it.

## Goals
- Requests come via a channel such as Email, Slack or TFS Work Item (we created a custom TFS work item type called Issue to deal with and track these)
- They are somewhat recurrent and people ask for them in a predictable way
- They require someone's approval before they execute
- They are requested in plain english (no TPS Report cover sheets needed)

## Examples of requests
- Hi, could you tell me how many words are in this file? Thanks in advance
- Please whitelist 192.168.1.1 for Emily, she's our newest admin
- We need a new distribution list created called "New Years Party 2018" with the following people: Joe Smith <jsmith@example.com>; Jamie Doe <jdoe@example.com>
- Please move ikhan@example.com to the Design Team department
- I need a report of last week's site traffic

## License Information

CognitiveMinion is Copyright (C) 2018 opsAI and is licensed under the MIT license:

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

## Luis.AI REST API docs
https://westus.dev.cognitive.microsoft.com/docs/services/5890b47c39e2bb17b84a55ff/operations/5890b47c39e2bb052c5b9c2f

	
## Installing via NuGet

The easiest way to install Cognitive Minion is via [NuGet](https://www.nuget.org/packages/CognitiveMinion/).

In Visual Studio's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console), enter the following command:

    Install-Package CognitiveMinion


## Installing as a Windows Service:
sc create CognitiveMinion.UserServices binPath= "E:\Applications\CognitiveMinion.UserServices\CognitiveMinion.UserServices.exe"


### Background on service structure:
https://www.stevejgordon.co.uk/running-net-core-generic-host-applications-as-a-windows-service

