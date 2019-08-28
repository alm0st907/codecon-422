# codecon-422
DEFCON scale based task tracker project for CptS 422

## Summary:
This will act initially as a standalone alternative to a Jira or similar issue based tracking system, however we plan to integrate with github/gitlab issues time permitting

Issues will be tied to DEFCON levels of severity and assigned due dates. DEFCON 5 is the best state and the project will hit all deadlines on time or early. DEFCON 1 represents project failure or immenent failure to meet deadline/spec.

Issues that are not resolved by due dates escalate the DEFCON level of the project which represents the health or launch readiness of the project by its projected deadline.

&nbsp;

Project Members
* Garrett Rudisill
* Mike Berger
* Slater Weinstock
* Jeff Kremer

# **STARTING GUIDE**

**Download node+npm for your os**

- `cd codecon`
  
# Installing Dependencies for ReactJS:

`bash install.sh`

# Building Locally:

- To begin running the app, `npm start` which builds on localhost
- With every saved change, the webpage is re-rendered

# Editing VSCode for JSX linting:
- VSCode->Settings->Extensions->settings.json
- Add the following to the settings.json for emmet:
  
    "emmet.includeLanguages": {
        "javascript": "javascriptreact"
    }
- In VSCode, install the vscode-styled-components extension 


# Common Build Errors Encountered:
- it's better to use VSCode's line commenting command as react can be very finicky depending on the placement of comments **(This is especially important when working with Konva which detects spaces as text and will fail)**

# How to write React code:
- React used to have stateless and stateful components.  There were referred to as functional vs class components.  Nowadays, functional components when used with React v>16.8 have access to hooks, which allow data management such that in the future functional components will have all the features of class components.  However, class components ***will*** work just fine and there are no plans to remove this.  If writing functional components with hooks, be careful as some third-party packages may ***not*** support them.