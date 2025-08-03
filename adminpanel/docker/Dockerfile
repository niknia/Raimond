# --------------------------------------------------
# Builder Stage - Build the app with dependencies
# --------------------------------------------------
FROM docker.arvancloud.ir/node:lts-alpine AS base
LABEL stage="builder"

# Set environment variables
ENV NODE_ENV=production \
    NEXT_TELEMETRY_DISABLED=1 \
    PNPM_HOME=/home/node/.local/share/pnpm \
    PATH="/home/node/.local/share/pnpm:$PATH" \
    NX_DAEMON=false



# Create non-root user
RUN addgroup --system --gid 1001 nodejs && \
    adduser --system --uid 1001 nextjs

# Set up pnpm directory
RUN mkdir -p /home/node/.local/share/pnpm && \
    chown -R nextjs:nodejs /home/node

# Set working directory
WORKDIR /app

# Accept build argument for auth token
# ARG NPMJS_PROXY_TOKEN

# Generate .npmrc dynamically using the token
# RUN echo "registry=https://nexus.devdkd.ir/repository/dkdnpm/" > .npmrc && \
#     echo "//nexus.devdkd.ir/repository/dkdnpm/:_authToken=Npm.getToken(\"admin\", \"A@a123\")" >> .npmrc && \
#     echo "//nexus.devdkd.ir/repository/dkdnpm/:username=admin" >> .npmrc && \
#     echo "//nexus.devdkd.ir/repository/dkdnpm/:password=A@a123" >> .npmrc && \
#     echo "//nexus.devdkd.ir/repository/dkdnpm/:email=noreply@example.com" >> .npmrc


# Copy package files first
COPY package.json pnpm-lock.yaml ./
COPY pnpm-workspace.yaml ./
#COPY .npmrc ./
COPY apps/adminpanel/package.json ./apps/adminpanel/
COPY packages/utils/package.json ./packages/utils/
COPY packages/dkd-axios/package.json ./packages/dkd-axios/
COPY packages/dkd-db/package.json ./packages/dkd-db/
COPY packages/dkd-font-factory/package.json ./packages/dkd-font-factory/
COPY packages/dkd-grid/package.json ./packages/dkd-grid/
COPY packages/dkd-logger/package.json ./packages/dkd-logger/
COPY packages/dkd-query/package.json ./packages/dkd-query/
COPY packages/dkd-redux/package.json ./packages/dkd-redux/
COPY packages/hook-form-mantine/package.json ./packages/hook-form-mantine/
COPY packages/hooks/package.json ./packages/hooks/
COPY packages/panel-kit/package.json ./packages/panel-kit/
COPY packages/tailwind-config/package.json ./packages/tailwind-config/

# Install dependencies using full path to pnpm
# RUN /root/.local/share/pnpm/pnpm config set registry https://nexus.devdkd.ir/repository/npmjs-proxy/  && \
#     /root/.local/share/pnpm/pnpm install --no-frozen-lockfile

# Install pnpm and dependencies
RUN corepack enable && \
    corepack prepare pnpm@latest --activate && \
    pnpm fetch && \
    pnpm install --no-frozen-lockfile    

# Install required system dependencies
RUN apk add --no-cache libc6-compat

# Configure pnpm
RUN pnpm config set store-dir $PNPM_HOME

# Copy source code
COPY . .


# Build packages in correct order
RUN pnpm nx run utils:build --skip-nx-cache && \
    pnpm nx run @dkd/logger:build --skip-nx-cache && \
    pnpm nx run @dkd-axios:build --skip-nx-cache && \
    pnpm nx run @dkd-db:build --skip-nx-cache && \
    pnpm nx run @dkd-font-factory:build --skip-nx-cache && \
    pnpm nx run @dkd-grid:build --skip-nx-cache && \
    pnpm nx run @dkd-query:build --skip-nx-cache && \
    pnpm nx run @dkd-redux:build --skip-nx-cache && \
    pnpm nx run @dkd/hook-form-mantine:build --skip-nx-cache && \
    pnpm nx run @dkd-hooks:build --skip-nx-cache && \
    pnpm nx run @tailwind-config:build --skip-nx-cache &&\
    pnpm nx run @dkd/panel-kit:build --skip-nx-cache
    

# Build the application
RUN pnpm nx build adminpanel --skip-nx-cache

# Production stage
FROM docker.arvancloud.ir/node:lts-alpine AS runner
LABEL stage="runner"

# Set environment variables
ENV NODE_ENV=production \
    NEXT_TELEMETRY_DISABLED=1 \
    PNPM_HOME=/home/node/.local/share/pnpm \
    PATH="/home/node/.local/share/pnpm:$PATH"


# Create non-root user
RUN addgroup --system --gid 1001 nodejs && \
    adduser --system --uid 1001 nextjs

# Set working directory
WORKDIR /app

# Install pnpm
RUN corepack enable && \
    corepack prepare pnpm@latest --activate

# Copy package files and install production dependencies
COPY --from=base /app/package.json /app/pnpm-lock.yaml ./
COPY --from=base /app/pnpm-workspace.yaml ./
#COPY --from=base /app/.npmrc ./
COPY --from=base /app/apps/adminpanel/package.json ./apps/adminpanel/
COPY --from=base /app/packages/utils/package.json ./packages/utils/
COPY --from=base /app/packages/dkd-axios/package.json ./packages/dkd-axios/
COPY --from=base /app/packages/dkd-db/package.json ./packages/dkd-db/
COPY --from=base /app/packages/dkd-font-factory/package.json ./packages/dkd-font-factory/
COPY --from=base /app/packages/dkd-grid/package.json ./packages/dkd-grid/
COPY --from=base /app/packages/dkd-logger/package.json ./packages/dkd-logger/
COPY --from=base /app/packages/dkd-query/package.json ./packages/dkd-query/
COPY --from=base /app/packages/dkd-redux/package.json ./packages/dkd-redux/
COPY --from=base /app/packages/hook-form-mantine/package.json ./packages/hook-form-mantine/
COPY --from=base /app/packages/hooks/package.json ./packages/hooks/
COPY --from=base /app/packages/panel-kit/package.json ./packages/panel-kit/
COPY --from=base /app/packages/tailwind-config/package.json ./packages/tailwind-config/


# Copy built files
COPY --from=base --chown=nextjs:nodejs /app/dist ./dist
COPY --from=base --chown=nextjs:nodejs /app/node_modules ./node_modules

# Switch to non-root user
USER nextjs

# Expose the port
EXPOSE 3000

# Start the application
WORKDIR /app/dist/apps/adminpanel
CMD ["pnpm", "start"]