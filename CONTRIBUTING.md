# Making contributions

* [Thank You!](#thank-you)
* [TL;DR: 10 Steps To Your First Pull Request](#pr-recipe)
* [Community guidelines](#community-guidelines)
* [Whom to contact in case of questions](#whom-to-contact)
* [How to submit a bug report](#submitting-bug-reports)
* [How to submit a feature request](#submitting-feature-requests)
* [How to contribute code](#contributing-code)
    * [Coding Conventions](#coding-conventions)
    * [Testing Conventions](#testing-conventions)
    * [Branching Conventions](#branching-conventions)
    * [Commit Message Conventions](#commit-message-conventions)
    * [Writing Documentation](#writing-documentation)
    * [Pull Requests](#pull-requests)
        * [Conventions for communicating in Pull Request](#pr-signaling)
        * [Definition of done](#definition-of-done)
        * [General Tips](#pr-tips)
* [Other Contributions](#other-contributions)

## <a name="thank-you">Thank You!</a>

Before we get to the _fine print_ and nitty gritty of contributing, let us 
start by saying **Thank you!** for considering to make a contribution to this
repository. Public repositories exist and thrive because of people like you, who are 
willing to make contributions, share their knowledge with fellow developers
and subscribe to the ideas behind [Open Source](https://www.fsf.org/)
in general. Kudos to you!

## <a name="pr-recipe">TL;DR: 10 Steps To Your First Pull Request.</a>

Ok, this is a long document so let's TL;DR this. The following recipe quickly
outlines ten steps to your first successful contribution in the form of a
pull request. 

1. First, create an issue in our 
[Issue Tracker](https://github.com/scorixear/ZETA_Squared/issues) as a _feature issue_ and describe the
contribution you intend to make.

2. We use [_git flow_](http://nvie.com/posts/a-successful-git-branching-model) 
as our branching model. So before you start coding, create a local feature 
branch, on which you will make your changes. We use the following template for 
naming feature branches:
```
"feature/" <issue number> "---" <Short description>
```

Here are some examples for valid feature branch names:

    feature/3---enhance-core2-documentation
    feature/27---bugfix-connection-intermittently-closes
    
([More about our branching conventions](branching-conventions))

3. Make the changes in your local git repository and commit. ([More about our
   commit message conventions](#commit-message-conventions))

4. When you'd like to share your code and/or start a Pull Request to get
   feedback, push your commits to the repository.

5. Open the [_Branches_](https://github.com/scorixear/ZETA_Squared/branches) view in Github. Your    newly pushed branch should show
   up there. (Soon, all repositories will have an associated build job which will
   pick up your new branch and build it. The result of the build will be then
   presented in the _Pull-Request_. If the build would fail
   and you know how to fix it, please do so before referencing to an administrator.)
   If you don't, go ahead and start a Pull Request anyway to allow us to help
   you make the build green.
6. In the _Branches_ view, click on the _New pull request_ Button.
7. In upcoming dialog, make sure your new feature branch
   is selected as the _compare_ branch and that the correct base branch is
   selected as well. In most cases, you will want to make _develop_ the base
   branch, as we are using the _git flow_ branching model.
8. Enter a meaningful title, prefixed with the issue number and possibly a
   slightly longer version of your branch name. Here's an example:
```
    42 - Add method to access nb. of received bytes to BusConnection
```
9. Briefly describe the changes you are submitting in the _Description_ field.
   The goal here is to make the life of the reviewers as easy as possible by
   explaining what you did and why. The description can be formatted as
   markdown, so feel free to format, add code examples, link to specific lines
   of code or even add sketches or diagrams. You can also @-mention anyone on
   Github to inform them of the PR. (usually we do that by prefixing the
   @-mention with `/CC` or `/FYI`).
10. Every Pull Request will be reviewed and approved by at least one maintainer
   (see README.md) before it is merged. We usually specify one or more
   default assignees for each repository, so you don't necessarily have to
   specify a person here. If you'd like to request feedback from a specific
   person, though, feel free to mention him/her.
11. Click _Create pull request_ to start the review. ([More on our conventions
    for communicating within Pull Requests](#pr-signaling))

This is, in a nutshell, how you create a Pull Request. It sounds complicated at
first, but you'll quickly internalize the steps and will be able to create a
Pull Request in mere minutes or less.

## <a name="community-guidelines">Community Guidelines</a>

![ZETA_Squared](icons/Logo_small.svg) is an GPL community. We strive to 
work in accordance with the five Social Coding values:

- _Openness_: We welcome *everyone* to make contributions,
  regardless of gender, age, sexual orientation, education, experience,
  affiliation with group, business unit, divition or other discriminating
  factors.
- _Transparency_: We make our code, documentation and communication available
for everybody to see.
- _Voluntariness_: We prefer contributions to be made voluntarily by 
insinsically motivated community members.
- _Self-determination_: As a community, we ourselves decide *what* to work on, 
*when* to do it, with *which tools* we work and *what processes* we apply. 
- _Meritocracy_: Rank in our community is to be granted based on meritocratic
principles. That is: rank is determined by the amount and quality of 
contributions made to the community - both technically and socially.

In our daily work, this means that

- we treat each other with utmost respect,
- we consider voluntary contributions as gifts and treat both our contributions
and our contributors accordingly,
- we happily invest time into sharing our knowledge with fellow community 
members, even if it slows down progress in the short term and
- we value communication "out in the open" (our issue tracker, 
in Pull Requests) to one-on-one communication.

## <a name="whom-to-contact">Whom to contact in case of questions?</a>

In order to allow as many people to benefit from the Q&A around 
our work, please consider reading the[Wiki](https://github.com/scorixear/ZETA_Squared/wiki).

If, for some reason, you prefer kicking off the collaboration in a personal
conversation, please contact the maintainers of this repository, which are
listed in this repository's README.md.

## <a name="submitting-bug-reports">How to submit a bug report?</a> 

Found a bug? Great! A core task in improving our software is to identify any
flaws that may be present. The best place to report a bug is an Issue from the _bug issue template_.

If you're not sure if what you are encountering is actually a 
bug or a feature, don't hesitate to also contact us through email.

## <a name="submitting-feature-requests">How to submit a feature request?</a>

If you have suggestions for us on how to improve our code or
our documentation or have a new feature in mind, please by all 
means do let us know. The same rules apply as for bug reports:
issue and contact us via email.

## <a name="contributing-code">How to contribute code?</a>

If you have fixed a bug or have developed that new feature 
you would like to make available to your fellow users, or even
if you have fixed whitespace or formatting issues, we'd like 
to encourage you to contribute that to our codebase. In this repository,
we use [_Pull Requests_](#pull-requests) to facilitate all contributions. Every
Pull Request will be peer reviewed by at least one community
member, which is a great way to get in touch with each other. 

### <a name="coding-conventions">Coding Conventions</a> 

We have coding styleguides in place for all our projects.
The main rules will be enforced by the provided .editorconfig.

#### Clean Code

More important than writing code that adheres to our styleguide is writing 
_Clean Code_. We consider code to be _clean_, if it

- works,
- is easy to understand,
- is easy to modify and
- is easy to test.

Any code contribution will be reviewed by us with respect to these criteria.
We are more than happy and indeed consider it a core part of _being GPL_ to
invest time mentoring junior developers to help them create _cleaner_ code and
to improve future contributions.

In addition to these principles of clean code, we also try to _design our
architectures for participation_. That, to us, means to avoid unnecessary
complexity, tight coupling or complex dependency relationships. 

### <a name="testing-conventions">Testing Conventions</a>

We are convinced that writing testable code and writing tests is a precondition
for any software to be maintainable. Even though we do not prescribe fixed 
coverage thresholds for our tests, we encourage (and often will require) you to
write tests for code that needs to be maintainable where the effort is not 
excessive. This means, that we

- aim to write code with testability in mind (following the test first principle)
- write tests for everything we can test
- expose a submitted bug with a test first, before we implement a fix.

We also aim to write our tests such that they can be read as a specification
(because we usually don't spend time writing those). In practice, this means
that we use long, verbose and expressive names for tests which convey the 
condition being tested.

In our experience, writing tests can actually be a lot of fun. As a programmer,
you have more leeway to experiment and try new programming approaches when
writing tests. That is why we often try out new language features in our test 
code, first. And if you're following the test first principle, it's always 
quite rewarding to see those red test cases continue to turn green, once the
implementation is complete. Finally, only adequate tests will empower you to
continuously improve your codebase with refactorings, as they provide the 
reassurance that you didn't break anything accidentally.

### <a name="branching-conventions">Branching Conventions</a>

We implement the 
[_git flow_](http://nvie.com/posts/a-successful-git-branching-model). Write 
access to the `master`, `develop` and `release` branches is restricted to 
repository maintainers while everybody can create and push `feature` branches.
All changes on `develop` should be made by way of a merged and reviewed 
`feature` branch.

The following convention applies for naming feature branches:

    "feature/" <Issue Key> "---" <Short description>

Here are some examples for valid feature branch names:

    feature/1234---enhance-core2-documentation
    feature/1234---bugfix-connection-intermittently-closes

### <a name="commit-message-conventions">Commit Message Conventions</a>

Commit messages on `feature` branches should briefly describe the change
introduced with the commit and should also contain the id of the issue or
issues which the change pertains to. Here are some examples of good 
commit messages:

    "Added method to access number of received bytes to BusConnection (4711)"
    "0815: Fixed typo in readme.md"

### <a name="writing-documentation">Writing Documentation</a>

We follow these principles when documenting code:

- We aim at keeping documentation as close the the asset being documented as
possible. That is, where sensible, we use inline code documentation. 
- We favor [Markdown](https://daringfireball.net/projects/markdown) or other
text based means of generating documentation and try not to use proprietary
tools, such as Word or PowerPoint for that.
- We aim at providing our users with easy to understand instructions on how to 
use our code in each repositories/projects README.md.
- We favor code examples over analytical descriptions of our codebase.

### <a name="pull-requests">Pull Requests</a>

Pull Requests are our main vehicle for submitting, reviewing and merging new
code into our codebase. A Pull Request is more than just an easy interface to 
git: it is a powerful collaboration and communication tool. They are especially 
well suited to share knowledge and onboard new contributors. So if you are new 
to te community, submitting Pull Requests is an excellent way for you to engage
with us and for us to help you get started. Discussions and the Q&A that often
accompanies Pull Requests are archived and linkable and we thus use them to
disseminate knowledge about our codebase. 

#### <a name="pr-signaling">Conventions for communicating in Pull Requests</a>

Apart from the social aspects of interactions, we follow a couple of conventions for
signaling - that is: using the various technical means of communicating in
Pull Requests that are afforded to us by Github (our Social Coding platform).

Here are common signals and how you use our platform to set them.

- **Add s.o. as reviewer**: _"I'd like you to review my PR and I will not merge w/o your approval!"_
- **Approve a PR**: _"I'm ok with merging this PR. If there are open tasks, I expect these to be finished before merging and I trust you to do this w/o another review!"_
- **PR Needs Work**: _"I am not ok with merging this PR and I require changes to be made. I will re-review this PR after changes are made!"_
- **@-mention s.o. in PR description with /CC prefix**: _"I'd like you to have a look at this PR but I'm not asking for your formal approval!"_
- **@-mention s.o. in PR description with /FYI prefix**: _"Just so you know, we're working on this!"_
- **@-mention s.o. in comment as part of question**: _"Can you please reply to my question with a comment?"_
- **Reviewer adds task to PR**: _"This needs to be fixed before I merge this PR!"_
- **Author of PR adds task in response to comment of reviewer**: _"I will finish this** task before merging!"_
- **Mark task as completed**: _"This task is finished and I have pushed the changes!"_
- **Add 👍**: _"I agree with the statemens made in the comment!"_
- **Add 👎**: _"I disagree with the statemens made in the comment!"_
- **Add link to issue**: _"I will not make the change in this PR but will take care of it later!"_

Generally speaking, when signalling, try to

- be respectful,
- be concise, 
- be specific,
- clearly state your expectation and
- use links where possible (to files, lines in files, commits, pull requests, people, issues, other comments, ...)

#### <a name="definition-of-done">Definition of done</a>

We use the following checklist to determine if a PR is ready to merge:

- [The last build is _green_] _later_
- If new code was added or if a bug was fixed, corresponding tests have been added
- All tasks added by reviewers are resolved
- At least one maintainer has approved the PR and none has signaled _Needs Work_

#### <a name="pr-tips">General Tips</a>

- Keep your PRs as small as possible. The smaller the PR the higher the velocity of review and acceptance.
- Avoid conflating multiple issues in one PR. It will usually lead to huge PRs and make the job of a reviewer unnecessarily harder.
- Write a good description to allow the reviewer to quickly get an overview of your changes.
- Don't add more than two reviewers if you expect all of them to review. This will most likely block you.

## <a name="other-contributions">Other Contributions</a>

You don't have to be a coder to make a valuable contribution to this community!
There are many contributions that you can make as a non-coder that will be very
valuable to the community, such as

- giving feedback of any kind,
- reporting bugs,
- requesting features,
- adding new or improvements existing documentation,
- extend the [Wiki](https://github.com/scorixear/ZETA_Squared/wiki)
- helping other users to use our software,
- asking and/or answering questions in other issues,
- promoting Social Coding, our community and our software or
- designing artwork for our software

May the source be with you!
