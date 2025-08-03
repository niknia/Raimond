import {
  type UseControllerProps,
  useController,
  type FieldValues,
} from "react-hook-form";
import {
  FileInput as $FileInput,
  type FileInputProps as $FileInputProps,
} from "@mantine/core";

export type FileInputProps<T extends FieldValues> = UseControllerProps<T> & 
  Omit<$FileInputProps, "value" | "defaultValue" | "onChange">; // ❌ حذف onChange از props

export function FileInput<T extends FieldValues>({
  name,
  control,
  defaultValue,
  rules,
  shouldUnregister,
  multiple,
  ...props
}: FileInputProps<T>) {
  const {
    field: { value, onChange, ref, ...field }, // ✅ دریافت onChange از useController
    fieldState,
  } = useController<T>({
    name,
    control,
    defaultValue,
    rules,
    shouldUnregister,
  });

  return (
    <$FileInput
      value={
        multiple
          ? (Array.isArray(value) ? value : value ? [value] : [])
          : (Array.isArray(value) ? value[0] || null : value)
      }
      onChange={(file) => 
        onChange(multiple ? file ?? [] : Array.isArray(file) ? file[0] || null : file)
      } // ✅ مدیریت تغییر مقدار فایل
      error={fieldState.error?.message}
      ref={ref}
      {...field} // ✅ اطمینان از دریافت درست ref و name
      {...props} // 🛑 `onChange` دیگر در اینجا مقداردهی نمی‌شود
    />
  );
}
