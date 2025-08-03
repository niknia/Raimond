// scripts/postinstall.js
const fs = require('node:fs');
const path = require('node:path');

const source = path.join(__dirname, '../dist/styles.css');
const target = path.join(__dirname, '../dist/styles.css');

if (!fs.existsSync(path.dirname(target))) {
  fs.mkdirSync(path.dirname(target), { recursive: true });
}

fs.copyFileSync(source, target);