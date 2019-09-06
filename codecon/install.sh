#update version numbers and packages in script
echo "checking for missing packages:"

[ $(node -p "require('bootstrap/package.json').version") != "4.3.1" ] && npm install bootstrap
[ $(node -p "require('eslint/package.json').version") != "6.3.0" ] && npm install eslint
[ $(node -p "require('eslint-plugin-react/package.json').version") != "7.14.3" ] && npm install eslint-plugin-react
[ $(node -p "require('konva/package.json').version") != "4.0.7" ] && npm install konva
[ $(node -p "require('react/package.json').version") != "16.9.0" ] && npm install react
[ $(node -p "require('react-dom/package.json').version") != "16.9.0" ] && npm install react-dom
[ $(node -p "require('react-konva/package.json').version") != "16.9.0-0" ] && npm install react-konva
[ $(node -p "require('react-router-dom/package.json').version") != "5.0.1" ] && npm install react-router-dom
[ $(node -p "require('react-scripts/package.json').version") != "3.1.1" ] && npm install react-scripts
[ $(node -p "require('reactstrap/package.json').version") != "8.0.1" ] && npm install reactstrap
[ $(node -p "require('styled-components/package.json').version") != "4.3.2" ] && npm install styled-components

echo "done"
