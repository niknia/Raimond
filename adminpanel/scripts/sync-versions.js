const fs = require('fs');
const path = require('path');

// Read versions from the central config
const versions = JSON.parse(fs.readFileSync(path.resolve('package-versions.json'), 'utf8'));

// Helper to recursively find all package.json files in a directory (excluding node_modules)
function findPackageJsons(dir) {
  let results = [];
  const list = fs.readdirSync(dir);
  for (const file of list) {
    const filePath = path.join(dir, file);
    const stat = fs.statSync(filePath);
    if (stat && stat.isDirectory()) {
      if (file === 'node_modules') continue;
      results = results.concat(findPackageJsons(filePath));
    } else if (file === 'package.json') {
      results.push(filePath);
    }
  }
  return results;
}

// Start from root, apps, and packages
const roots = [
  '.',
  './apps',
  './packages',
];

let packageJsonPaths = [];
for (const root of roots) {
  const absRoot = path.resolve(root);
  if (fs.existsSync(absRoot)) {
    packageJsonPaths = packageJsonPaths.concat(findPackageJsons(absRoot));
  }
}

// Remove duplicates (in case root/package.json is found twice)
packageJsonPaths = [...new Set(packageJsonPaths)];

for (const pkgFullPath of packageJsonPaths) {
  const pkg = JSON.parse(fs.readFileSync(pkgFullPath, 'utf8'));
  let changed = false;
  for (const dep of Object.keys(versions)) {
    if (pkg.dependencies && pkg.dependencies[dep]) {
      pkg.dependencies[dep] = versions[dep];
      changed = true;
    }
    if (pkg.devDependencies && pkg.devDependencies[dep]) {
      pkg.devDependencies[dep] = versions[dep];
      changed = true;
    }
    if (pkg.peerDependencies && pkg.peerDependencies[dep]) {
      pkg.peerDependencies[dep] = versions[dep];
      changed = true;
    }
    if (pkg.resolutions && pkg.resolutions[dep]) {
      pkg.resolutions[dep] = versions[dep];
      changed = true;
    }
  }
  if (changed) {
    fs.writeFileSync(pkgFullPath, JSON.stringify(pkg, null, 2));
    console.log(`✅ Updated ${path.relative(process.cwd(), pkgFullPath)}`);
  } else {
    console.log(`ℹ️  No changes needed for ${path.relative(process.cwd(), pkgFullPath)}`);
  }
} 