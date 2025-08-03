// scripts/build-all.js

const { execSync } = require('node:child_process');
const fs = require('node:fs');
const path = require('node:path');

function run(cmd) {
  try {
    console.log(`\n🚀 Running: ${cmd}`);
    execSync(cmd, { stdio: 'inherit' });
  } catch (err) {
    console.error(`\n❌ Error executing command: ${cmd}`);
    console.error(`Error details: ${err.message}`);
    process.exit(1);
  }
}

function getPackageInfo(packagePath) {
  try {
    const packageJson = JSON.parse(fs.readFileSync(path.join(packagePath, 'package.json'), 'utf8'));
    let projectName = packageJson.name;
    
    // Try to read project.json for NX project name
    const projectJsonPath = path.join(packagePath, 'project.json');
    if (fs.existsSync(projectJsonPath)) {
      const projectJson = JSON.parse(fs.readFileSync(projectJsonPath, 'utf8'));
      if (projectJson.name) {
        projectName = projectJson.name;
      }
    }

    return {
      name: packageJson.name,
      projectName: projectName, // NX project name
      version: packageJson.version,
      folderName: path.basename(packagePath),
      dependencies: { 
        ...packageJson.dependencies || {},
        ...packageJson.devDependencies || {}
      }
    };
  } catch (err) {
    console.error(`\n❌ Error reading package info from ${packagePath}`);
    console.error(`Error details: ${err.message}`);
    process.exit(1);
  }
}

function validateDependencies(packagesInfo) {
  const errors = [];
  const warnings = [];

  for (const pkgInfo of packagesInfo) {
    // Check version format
    if (!/^\d+\.\d+\.\d+(-.*)?$/.test(pkgInfo.version)) {
      warnings.push(`⚠️ Package ${pkgInfo.name} has non-standard version format: ${pkgInfo.version}`);
    }

    // Check for circular dependencies
    const deps = Object.keys(pkgInfo.dependencies);
    if (deps.includes(pkgInfo.name)) {
      errors.push(`❌ Circular dependency detected in ${pkgInfo.name}`);
    }
  }

  if (warnings.length > 0) {
    console.log('\n⚠️ Warnings:');
    for (const warning of warnings) {
      console.log(warning);
    }
  }

  if (errors.length > 0) {
    console.error('\n❌ Errors found:');
    for (const error of errors) {
      console.error(error);
    }
    process.exit(1);
  }
}

function getBuildOrder() {
  const packagesDir = path.join(process.cwd(), 'packages');
  const packageFolders = fs.readdirSync(packagesDir)
    .filter(pkg => fs.statSync(path.join(packagesDir, pkg)).isDirectory());

  // Get package info for all packages
  const packagesInfo = packageFolders.map(folder => {
    const pkgInfo = getPackageInfo(path.join(packagesDir, folder));
    return pkgInfo;
  });

  // Create maps for package info
  const packageMaps = {};
  for (const pkgInfo of packagesInfo) {
    packageMaps[pkgInfo.name] = {
      folderName: pkgInfo.folderName,
      projectName: pkgInfo.projectName
    };
  }

  // Validate dependencies before proceeding
  validateDependencies(packagesInfo);

  // Create dependency graph using package names
  const graph = {};
  for (const pkgInfo of packagesInfo) {
    graph[pkgInfo.name] = Object.keys(pkgInfo.dependencies)
      .filter(dep => packagesInfo.some(p => p.name === dep));
  }

  // Topological sort
  const visited = new Set();
  const temp = new Set();
  const order = [];

  function visit(node) {
    if (temp.has(node)) {
      throw new Error(`Circular dependency detected with package: ${node}`);
    }
    if (visited.has(node)) return;
    
    temp.add(node);
    for (const dep of (graph[node] || [])) {
      visit(dep);
    }
    temp.delete(node);
    visited.add(node);
    order.push(node);
  }

  for (const node of Object.keys(graph)) {
    if (!visited.has(node)) {
      visit(node);
    }
  }

  // Return complete package info for the build
  return order.map(packageName => ({
    name: packageName,
    folderName: packageMaps[packageName].folderName,
    projectName: packageMaps[packageName].projectName
  }));
}

// Main build process
console.log('🔍 Analyzing package dependencies...');
const buildOrder = getBuildOrder();

console.log('\n📦 Building packages in order:');
console.log(buildOrder.map((pkg, i) => `${i + 1}. ${pkg.name} (${pkg.projectName})`).join('\n'));

for (const [index, pkg] of buildOrder.entries()) {
  console.log(`\n📦 [${index + 1}/${buildOrder.length}] Building ${pkg.name}...`);
  // Use projectName for nx build command, fallback to folderName if projectName is undefined
  const buildTarget = pkg.projectName || pkg.folderName;
  run(`pnpm nx build "${buildTarget}"`);
}

console.log('\n✅ All packages built successfully!');
