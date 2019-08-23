# codecon-422
Defcon scale based task tracker project for CptS 422
**Download node+npm for your os**

- `cd codecon`
  
# Installing Dependencies for ReactJS:

- **The package.json file should be updated such that you only have to do `npm i` and not run the next step.**
- Run `npm i react react-dom react-scripts bootstrap reactstrap react-konva konva react-router-dom styled-components eslint eslint-plugin-react` as this will install the dependencies.  

# Updating Packages:
  
- Run `npm i npm-check-updates -g`
- It is important to check for updates when inside the codecon directory, so run `ncu -u` and then `npm install`

# Building Locally:

- To begin running the app, `npm start` which builds on localhost
- With every saved change, the webpage is re-rendered

# Editing VSCode for JSX linting:
- VSCode->Settings->Extensions->settings.json
- Add the following to the settings.json for emmet:
  
    "emmet.includeLanguages": {
        "javascript": "javascriptreact"
    }
