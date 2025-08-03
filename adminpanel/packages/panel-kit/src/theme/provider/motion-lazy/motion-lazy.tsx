import { domMax, LazyMotion, m } from 'framer-motion'
import type { IMotionLazyProviderProps } from './motion-lazy.types'

export const MotionLazyProvider: React.FC<IMotionLazyProviderProps> = ({
  children,
}) => {
  return (
    <LazyMotion strict features={domMax}>
      <m.div style={{ height: '100%' }}> {children} </m.div>
    </LazyMotion>
  )
}
