#!/bin/bash

BUILD_DIR=$(date +%F%s)

mkdir -p "/tmp/$BUILD_DIR"

cp -rf "$CURRENT" "/tmp/$BUILD_DIR"

cd "/tmp/$BUILD_DIR"

cd luval.vision.webapp

rm -rf node_modules dist

npm install && npm run build

perl -pi -e 's/app\/documents\/documents-modal\//.\//g' $(find dist -type f -iname "app*.js" -print)

if [ ! -f dist/documents-modal.html ]; then
  find . -type f -name "documents-modal.html" -exec cp {} dist \;
fi

echo ".tmp" > .gitignore
echo "coverage" >> .gitignore
echo "node_modules" >> .gitignore
echo "README.md" >> .gitignore
echo "src" >> .gitignore

git init .

git remote add heroku https://git.heroku.com/celeris-staging.git

git add --all

git commit -m "deployment $(date +%F)"

echo "now cd into $PWD, and then"
echo -e "run\ngit push -f heroku master:master\nand\nheroku restart\n\nto complete deployment"
