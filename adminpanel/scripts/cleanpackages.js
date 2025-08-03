const fs = require('node:fs');
const path = require('node:path');

function removeDirectory(dirPath) {
  if (fs.existsSync(dirPath)) {
    fs.rmSync(dirPath, { recursive: true, force: true });
    return true;
  }
  return false;
}

function cleanPackage(packagePath) {
  const distPath = path.join(packagePath, 'dist');
  const nodeModulesPath = path.join(packagePath, 'node_modules');
  
  let cleaned = false;
  
  if (removeDirectory(distPath)) {
    console.log(`🗑️ Removed dist folder from ${path.basename(packagePath)}`);
    cleaned = true;
  }
  
  if (removeDirectory(nodeModulesPath)) {
    console.log(`🗑️ Removed node_modules folder from ${path.basename(packagePath)}`);
    cleaned = true;
  }
  
  if (!cleaned) {
    console.log(`✅ No folders to clean in ${path.basename(packagePath)}`);
  }
}

function processPackages() {
  const packagesDir = path.join(process.cwd(), 'packages');
  const packages = fs.readdirSync(packagesDir);
  
  console.log('🧹 Starting package cleanup...\n');
  
  for (const pkg of packages) {
    const pkgPath = path.join(packagesDir, pkg);
    if (fs.statSync(pkgPath).isDirectory()) {
      cleanPackage(pkgPath);
    }
  }
  
  console.log('\n✨ Cleanup completed!');
}

// Run the script
processPackages(); 