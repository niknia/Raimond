const { execSync } = require('node:child_process');
const fs = require('node:fs');
const path = require('node:path');

function run(cmd) {
  try {
    console.log(`\n🚀 Running: ${cmd}`);
    execSync(cmd, { stdio: 'inherit' });
  } catch (err) {
    console.error(`❌ Error while running: ${cmd}`);
    process.exit(1);
  }
}

function checkAndInstallDependencies(packagePath) {
  const nodeModulesPath = path.join(packagePath, 'node_modules');
  const packageJsonPath = path.join(packagePath, 'package.json');
  
  if (!fs.existsSync(packageJsonPath)) {
    console.log(`⚠️ No package.json found in ${packagePath}`);
    return;
  }

  if (!fs.existsSync(nodeModulesPath)) {
    console.log(`📦 Installing dependencies for ${path.basename(packagePath)}...`);
    run(`cd ${packagePath} && pnpm install`);
  } else {
    console.log(`✅ Dependencies already installed for ${path.basename(packagePath)}`);
  }
}

function processPackages() {
  const packagesDir = path.join(process.cwd(), 'packages');
  const packages = fs.readdirSync(packagesDir);
  
  console.log('🔍 Checking packages for dependencies...\n');
  
  for (const pkg of packages) {
    const pkgPath = path.join(packagesDir, pkg);
    if (fs.statSync(pkgPath).isDirectory()) {
      checkAndInstallDependencies(pkgPath);
    }
  }
  
  console.log('\n✅ All packages checked and dependencies installed!');
}

// Run the script
processPackages(); 